<template>
    <div :id="uid" class="block-group">
        <div class="actions block-group-actions">
            <button v-on:click.prevent="piranha.blockpicker.open(addGroupBlock, model.items.length, model.type)" class="btn btn-sm add">
                <i class="fas fa-plus"></i>
            </button>
            <button v-if="model.fields.length > 0" v-on:click.prevent="toggleHeader()" class="btn btn-sm" :class="{ selected: model.meta.showHeader }">
                <i class="fas fa-list"></i>
            </button>
        </div>
        <div class="row">
            <div class="col">
                <div class="list-group list-group-flush">
                    <div class="list-group-item" :class="{ active: child.isActive }" v-for="child in model.items" v-bind:key="child.meta.uid">
                        <a class="item-link" href="#" v-on:click.prevent="selectItem(child)" :class="isEmptyTitle(child.model)?'empty-text':''">
                            <div class="handle">
                                <i class="fas fa-arrows-alt"></i>
                            </div>
                            <div contenteditable="true" spellcheck="false" v-text="getTitle(child.model)"
                                 v-on:blur="titleOnBlur($event, child.model)" v-on:focus="titleOnFocus($event, child.model)"></div>
                        </a>
                        <span class='actions'>
                            <a v-on:click.prevent="removeItem(child)" href="#"><i class="fas fa-times"></i></a>
                        </span>
                    </div>
                </div>

                <div v-if="model.items.length === 0" class="empty-info unsortable">
                    <p>{{ piranha.resources.texts.emptyAddLeft }}</p>
                </div>
                <div :id="uid + '_tab_wrapper'" class="block-tab-wrapper">
                    <template v-for="child in model.items">
                        <div class="block" :class="child.meta.component" v-if="child.isActive" v-bind:key="'details-' + child.meta.uid">
                            <component v-bind:is="child.meta.component" v-bind:uid="child.meta.uid" v-bind:toolbar="uid + '_tab_wrapper'" v-bind:model="child.model"></component>
                        </div>
                    </template>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        props: ["uid", "toolbar", "model"],
        data: function () {
            return {
                emptyTitleText: "Tab name..."
            }
        },
        methods: {
            selectItem: function (item) {
                for (var n = 0; n < this.model.items.length; n++) {
                    if (this.model.items[n] == item) {
                        this.model.items[n].isActive = true;
                    } else {
                        this.model.items[n].isActive = false;
                    }
                }
            },
            removeItem: function (item) {
                var itemActive = item.isActive;
                var itemIndex = this.model.items.indexOf(item);

                this.model.items.splice(itemIndex, 1);

                if (itemActive) {
                    this.selectItem(this.model.items[Math.min(itemIndex, this.model.items.length - 1)]);
                }
            },
            addGroupBlock: function (type, pos) {
                var self = this;

                fetch(piranha.baseUrl + "manager/api/content/block/" + type)
                    .then(function (response) { return response.json(); })
                    .then(function (result) {
                        self.model.items.push(result.body);
                        self.selectItem(result.body);
                    })
                    .catch(function (error) {
                        console.log("error:", error);
                    });
            },
            toggleHeader: function () {
                this.model.meta.showHeader = !this.model.meta.showHeader;
            },
            moveItem: function (from, to) {
                this.model.items.splice(to, 0, this.model.items.splice(from, 1)[0])
            },
            titleOnFocus: function (e, model) {
                if (e.target.innerText == this.emptyTitleText) {
                    e.target.innerText = "";
                }
            },
            titleOnBlur: function (e, model) {
                if (piranha.utils.isEmptyText(e.target.innerText)) {
                    e.target.innerText = this.emptyTitleText;
                }

                model.title.value = e.target.innerText;
            },
            isEmptyTitle: function (model) {
                return piranha.utils.isEmptyText(model.title.value)
                    || (model.title.value == this.emptyTitleText);
            },
            getTitle: function (model) {
                return piranha.utils.isEmptyText(model.title.value) ? this.emptyTitleText : model.title.value;
            }
        },
        mounted: function () {
            var self = this;

            sortable("#" + this.uid + " .list-group", {
                items: ":not(.unsortable)"
            })[0].addEventListener("sortupdate", function (e) {
                self.moveItem(e.detail.origin.index, e.detail.destination.index);
            });
        }
    }
</script>