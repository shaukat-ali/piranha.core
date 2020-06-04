<template>
    <div :id="uid" class="block-group">
        <div class="actions block-group-actions">
            <button v-on:click.prevent='toggleHeader()' v-if='model.fields.length > 0' class='btn btn-sm' :class='{ selected: model.meta.showHeader }'>
                <i class="fas fa-list"></i>
            </button>
        </div>
        <div class="row block-group-items">
            <div v-for="child in model.items" v-bind:key="child.meta.uid" class="col">
                <div class="block" :class="child.meta.component">
                    <component v-bind:is="child.meta.component" v-bind:uid="child.meta.uid" v-bind:toolbar="toolbar" v-bind:model="child.model"></component>
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