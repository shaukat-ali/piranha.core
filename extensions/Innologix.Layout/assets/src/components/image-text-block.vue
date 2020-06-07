<template>
    <div class="row block-body">
        <div class="image-block col">
            <div class="has-media-picker" :class="{ empty: isMediaEmpty }">
                <img v-if="!isMediaEmpty" :src="mediaUrl">
                <div class="media-picker" :class="{ 'has-image': isImage }" v-if="!showLinker">
                    <div class="btn-group float-right">
                        <button v-if="!isMediaEmpty && isImage" v-on:click.prevent="linkMedia" class="btn btn-info text-center">
                            <i class="fas fa-link"></i>
                        </button>
                        <button v-on:click.prevent="selectMedia" class="btn btn-primary text-center">
                            <i class="fas fa-plus"></i>
                        </button>
                        <button v-if="!isMediaEmpty" v-on:click.prevent="removeMedia" class="btn btn-danger text-center">
                            <i class="fas fa-times"></i>
                        </button>
                    </div>
                </div>
                <div class="media-linker" v-if="!isMediaEmpty && isImage && showLinker">
                    <div class="btn-group float-right">
                        <button v-on:click.prevent="saveLink" class="btn btn-success text-center">
                            <i class="fas fa-check"></i>
                        </button>
                        <button v-on:click.prevent="removeLink" class="btn btn-danger text-center">
                            <i class="fas fa-times"></i>
                        </button>
                    </div>
                    <div class="card text-left">
                        <input type="text" :value="model.imageCTALink.value" :id="uid + '_link'" />
                    </div>
                </div>
            </div>
        </div>
        <div class="content-block col">
            <div class="title" :class="{ empty: isEmptyTitle }">
                <div contenteditable="true" spellcheck="false" v-text="title" v-on:blur="onTitleBlur" v-on:focus="onTitleFocus"></div>
            </div>
            <div class="description" :class="{ empty: isEmptyContent }" :id="uid + '_description'">
                <div contenteditable="true" :id="uid" spellcheck="false" v-html="body" v-on:blur="onBodyBlur" v-on:focus="onBodyFocus"></div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        props: ["uid", "toolbar", "model"],
        data: function () {
            return {
                emptyTitleText: "Add title...",
                emptyDescriptionText: "Add description...",
                showLinker: false
            };
        },
        methods: {
            onTitleBlur: function (e) {
                if (piranha.utils.isEmptyText(e.target.innerText)) {
                    e.target.innerText = this.emptyTitleText;
                }

                this.model.title.value = e.target.innerText;
            },
            onTitleFocus: function (e) {
                if (e.target.innerText == this.emptyTitleText) {
                    e.target.innerText = "";
                }
            },
            onBodyBlur: function (e) {
                if (piranha.utils.isEmptyText(e.target.innerText)) {
                    e.target.innerText = this.emptyDescriptionText;
                }

                this.model.body.value = e.target.innerHTML;
            },
            onBodyFocus: function (e) {
                if (e.target.innerText == this.emptyDescriptionText) {
                    e.target.innerHTML = "";
                }
            },
            onBodyChange: function (data) {
                this.model.body.value = data;
            },
            selectMedia: function () {
                if (this.model.media.media != null) {
                    piranha.mediapicker.open(this.updateMedia, "Image", this.model.media.media.folderId);
                } else {
                    piranha.mediapicker.openCurrentFolder(this.updateMedia, "Image");
                }
            },
            removeMedia: function () {
                this.model.media.id = null;
                this.model.media.media = null;
            },
            updateMedia: function (media) {
                if (media.type === "Image" || media.type === "Video") {
                    this.model.media.id = media.id;
                    this.model.media.media = {
                        id: media.id,
                        folderId: media.folderId,
                        type: media.type,
                        filename: media.filename,
                        contentType: media.contentType,
                        publicUrl: media.publicUrl,
                    };
                } else {
                    console.log("Media not supported");
                }
            },
            linkMedia: function () {
                this.showLinker = true;
            },
            saveLink: function () {
                var txtBox = document.getElementById(this.uid + '_link');
                this.model.imageCTALink.value = txtBox.value;
                this.showLinker = false;
            },
            removeLink: function () {
                var txtBox = document.getElementById(this.uid + '_link');
                this.model.imageCTALink.value = txtBox.value = "";
                this.showLinker = false;
            }
        },
        computed: {
            isEmptyTitle: function () {
                return piranha.utils.isEmptyText(this.model.title.value)
                    || (this.model.title.value == this.emptyTitleText);
            },
            isEmptyContent: function () {
                return piranha.utils.isEmptyHtml(this.model.body.value)
                    || (this.model.body.value == this.emptyDescriptionText);
            },
            isMediaEmpty: function () {
                return this.model.media.media == null;
            },
            isImage: function () {
                return this.model.media.media != null
                    && (this.model.media.media.type === "Image" || this.model.media.media.type == 2);
            },
            title: function () {
                return this.isEmptyTitle ? this.emptyTitleText : this.model.title.value;
            },
            body: function () {
                return this.isEmptyContent ? this.emptyDescriptionText : this.model.body.value;
            },
            mediaUrl: function () {
                if (this.model.media.media != null) {
                    return piranha.utils.formatUrl(this.model.media.media.publicUrl);
                } else {
                    return piranha.utils.formatUrl("~/manager/assets/img/empty-image.png");
                }
            }
        },
        mounted: function () {
            piranha.editor.addInlineMinimal(this.uid, this.uid + '_description', this.onBodyChange);
        },
        beforeDestroy: function () {
            piranha.editor.remove(this.uid);
        }
    }
</script>