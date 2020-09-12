<template>
  <div>
      <b-container fluid="lg">
          <h2>Knowledge Items</h2>
          <div id="mess-list" v-if="this.knowledgeItemList">
              <div v-for="knowledgeItem in this.knowledgeItemList" v-bind:key="knowledgeItem.id">
                  <h4>{{knowledgeItem.title}} (id = {{knowledgeItem.id}}) </h4>
                  <p>{{knowledgeItem.summary}}</p>
              </div>
          </div>
      </b-container>
  </div>
</template>

<script>
    import KnowledgeService from '@/services/KnowledgeService'
    import { mapGetters } from 'vuex'

    export default {
        async mounted() {
            await KnowledgeService.getKnowledgeItems()
        },
        computed: {
            ...mapGetters(['knowledgeItemList'])
        }
    }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
