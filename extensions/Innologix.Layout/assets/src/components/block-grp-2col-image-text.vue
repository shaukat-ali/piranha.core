<template>
    <div :id="uid" class="block-group">
        <div class="actions block-group-actions">
            <button v-on:click.prevent='toggleHeader()' v-if='model.fields.length > 0' class='btn btn-sm' :class='{ selected: model.meta.showHeader }'>
                <i class="fas fa-list"></i>
            </button>
        </div>
        <div v-if="model.meta.showHeader && model.fields.length > 0" class="block-group-header">
            <div class="row">
                <div class="form-group" :class="{ 'col-sm-6': field.meta.isHalfWidth, 'col-sm-12': !field.meta.isHalfWidth }" v-bind:key="field.meta.id" v-for="field in model.fields">
                    <label>{{ field.meta.name }}</label>
                    <div v-if="field.meta.description != null" v-html="field.meta.description" class="field-description small text-muted"></div>
                    <component v-bind:is='field.meta.component' v-bind:uid='field.meta.uid' v-bind:meta='field.meta' v-bind:toolbar='toolbar' v-bind:model='field.model'></component>
                </div>
            </div>
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