<template>
    <div>
        <div v-for="user in users" :key="user.id">
            {{user.Name}}
        </div>
    </div>
</template>

<script>
    import { mapState } from "vuex";

    export default {
        computed: {
            ...mapState(['users'])
        },
        mounted() {
            this.$store.dispatch("loadUsers")
        },
        
    }
</script>

<style lang="scss" scoped>

</style>