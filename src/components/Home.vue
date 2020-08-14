<template>
    <section>
        <div :style="image" class="image"></div> 
    </section>

</template>

<script>


    export default {
        data() {
            return {
                image: {backgroundImage: "url(https://www.kcm-cg.com/wp-content/uploads/2013/01/Best-top-desktop-golf-wallpapers-hd-golf-wallpaper-sport-pictures-02.jpeg)"}
            };
        },
    };

</script>

<style>
    .image {
        height: 150px;
        background-repeat: no-repeat;
    }
</style>