<template>
    <div :id="uid" class="block-group">
        <div class="actions block-group-actions">
            <button v-on:click.prevent='toggleHeader()' v-if='model.fields.length > 0' class='btn btn-sm' :class='{ selected: model.meta.showHeader }'>
                <i class="fas fa-list"></i>
            </button>
        </div>
        <div class="row block-group-items">
            <div class="col grp-block-1">
                <div class="block" :class="model.items[0].meta.component">
                    <component v-bind:is="model.items[0].meta.component" v-bind:uid="model.items[0].meta.uid" v-bind:model="model.items[0].model"></component>
                </div>
                <div class="block" :class="model.items[1].meta.component">
                    <component v-bind:is="model.items[1].meta.component" v-bind:uid="model.items[1].meta.uid" v-bind:model="model.items[1].model"></component>
                </div>
            </div>
            <div class="col grp-block-2">
                <div class="block" :class="model.items[2].meta.component">
                    <component v-bind:is="model.items[2].meta.component" v-bind:uid="model.items[2].meta.uid" v-bind:model="model.items[2].model"></component>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        props: ["uid", "toolbar", "model"],
        methods: {
            toggleHeader: function () {
                this.model.meta.showHeader = !this.model.meta.showHeader;
            }
        }
    }
</script>