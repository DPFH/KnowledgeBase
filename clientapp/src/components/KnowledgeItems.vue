<template>
  <div>
    <b-container fluid="lg">
        <h1>Knowledge Items</h1>
    </b-container>
  </div>
</template>

<script>
    import KnowledgeService from '@/services/KnowledgeService'

    export default {
        async mounted() {
            await KnowledgeService.getKnowledgeItems()
        }
    }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
