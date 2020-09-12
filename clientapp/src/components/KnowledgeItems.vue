<template>
  <div>
      <b-container fluid="lg">
          <h3 class="mb-2">Knowledge Items:</h3>
          <div id="mess-list" v-if="this.knowledgeItemList">
              <div v-for="knowledgeItem in this.knowledgeItemList" v-bind:key="knowledgeItem.id" class="ItemBorder">
                  <h4>{{knowledgeItem.title}} (id = {{knowledgeItem.id}})</h4>
                  <p class="mb-3">{{knowledgeItem.summary}}</p>
                  <p class="KIfooterStamp">Created by {{knowledgeItem.createdBy}} on {{knowledgeItem.createdDate}}</p>
                  <p class="KIfooterStamp">Last edited by {{knowledgeItem.editedBy}} on {{knowledgeItem.editedDate}}</p>
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
    .KIfooterStamp {
        text-align: right;
        margin-bottom: 0.25rem;
    }
    .ItemBorder {
        padding-top: 0.5rem;
        padding-bottom: 0.5rem;
        border-top: 1px solid #000000;
    }
</style>
