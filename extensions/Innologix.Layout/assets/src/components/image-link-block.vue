<template>
    <div class="block-body has-media-picker rounded" :class="{ empty: isEmpty }">
        <img v-if="!isEmpty" :src="mediaUrl">
        <div class="media-picker has-image" v-if="!showLinker">
            <div class="btn-group float-right">
                <button v-if="!isEmpty" v-on:click.prevent="link" class="btn btn-info text-center">
                    <i class="fas fa-link"></i>
                </button>
                <button v-on:click.prevent="select" class="btn btn-primary text-center">
                    <i class="fas fa-plus"></i>
                </button>
                <button v-if="!isEmpty" v-on:click.prevent="remove" class="btn btn-danger text-center">
                    <i class="fas fa-times"></i>
                </button>
            </div>
        </div>
        <div class="media-linker" v-if="!isEmpty && showLinker">
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
</template>

<script>
    export default {
        props: ["uid", "model"],
        data: function () {
            return {
                showLinker: false
            };
        },
        methods: {
            clear: function () {
                // clear media from block
            },
            select: function () {
                if (this.model.body.media != null) {
                    piranha.mediapicker.open(this.update, "Image", this.model.body.media.folderId);
                } else {
                    piranha.mediapicker.openCurrentFolder(this.update, "Image");
                }
            },
            remove: function () {
                this.model.body.id = null;
                this.model.body.media = null;
            },
            update: function (media) {
                if (media.type === "Image") {
                    this.model.body.id = media.id;
                    this.model.body.media = {
                        id: media.id,
                        folderId: media.folderId,
                        type: media.type,
                        filename: media.filename,
                        contentType: media.contentType,
                        publicUrl: media.publicUrl,
                    };

                    // Tell parent that title has been updated
                    this.$emit('update-title', {
                        uid: this.uid,
                        title: this.model.body.media.filename
                    });
                } else {
                    console.log("No image was selected");
                }
            },
            link: function () {
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
            isEmpty: function () {
                return this.model.body.media == null;
            },
            mediaUrl: function () {
                if (this.model.body.media != null) {
                    return piranha.utils.formatUrl(this.model.body.media.publicUrl);
                } else {
                    return piranha.utils.formatUrl("~/manager/assets/img/empty-image.png");
                }
            }
        },
        mounted: function () {
            this.model.getTitle = function () {
                if (this.model.media != null) {
                    return this.model.media.filename;
                } else {
                    return "No image selected";
                }
            };
        }
    }
</script>