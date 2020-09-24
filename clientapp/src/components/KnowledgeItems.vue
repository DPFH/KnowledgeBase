<template>
  <div>
      <b-container fluid="lg">
          <h3 class="mb-2">Knowledge Items:</h3>
          <b-button v-b-modal.create-modal block variant="primary">Create a Knowledge Item</b-button>
          <b-modal id="create-modal"
                   size="lg"
                   @show="resetModal"
                   @hidden="resetModal"
                   @ok="handleOk"
                   title="Create Knowledge Item Form">
              <b-form ref="form" @submit.stop.prevent="handleSubmit">
                  <b-form-group id="input-group-title"
                                invalid-feedback="Title is required"
                                label="Title:"
                                label-for="title-input">
                      <b-form-input id="title-input"
                                    v-model="title"
                                    :state="titleState"
                                    type="text"
                                    required
                                    placeholder="Enter title">
                      </b-form-input>
                  </b-form-group>
                  <b-form-group id="input-group-summary"
                                invalid-feedback="Summary is required"
                                label="Summary:"
                                label-for="summary-input">
                      <b-form-textarea id="summary-input"
                                    v-model="summary"
                                    :state="summaryState"
                                    type="text"
                                    required
                                    placeholder="Enter summary"
                                    :rows="5">
                      </b-form-textarea>
                  </b-form-group>
                  <b-form-group id="input-group-createdDate"
                                invalid-feedback="Date created is required"
                                label="Date Created:"
                                label-for="created-date-input">
                      <b-form-input id="created-date-input"
                                    v-model="createdDate"
                                    :state="createdDateState"
                                    type="text"
                                    required
                                    placeholder="Enter date created">
                      </b-form-input>
                  </b-form-group>
                  <b-form-group id="input-group-createdBy"
                                invalid-feedback="Creator name is required"
                                label="Created By:"
                                label-for="created-by-input">
                      <b-form-input id="created-by-input"
                                    v-model="createdBy"
                                    :state="createdByState"
                                    type="text"
                                    required
                                    placeholder="Enter name of creator">
                      </b-form-input>
                  </b-form-group>
              </b-form>
          </b-modal>
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
        data() {
            return {
                title: '',
                summary: '',
                createdDate: '',
                createdBy: '',
                titleState: null,
                summaryState: null,
                createdDateState: null,
                createdByState: null
            }
        },
        methods: {
            resetModal() {
                this.title = '',
                this.summary = '',
                this.createdDate = '',
                this.createdBy = '',
                this.titleState = null,
                this.summaryState = null,
                this.createdDateState = null,
                this. createdByState = null
            },
            checkFormValidity() {
                const valid = this.$refs.form.checkValidity()
                this.titleState = this.title.length == 0 ? false : true
                this.summaryState = this.summary.length == 0 ? false : true
                this.createdDateState = this.createdDate.length == 0 ? false : true
                this.createdByState = this.createdBy.length == 0 ? false : true
                return valid
            },
            handleOk(bvModalEvt) {
                bvModalEvt.preventDefault()
                this.handleSubmit()
            },
            async createKnowledgeItem() {
                var obj = {
                    title: this.title,
                    summary: this.summary,
                    createdDate: this.createdDate,
                    editedDate: this.createdDate,
                    createdBy: this.createdBy,
                    editedBy: this.createdBy
                }

                try {
                    await KnowledgeService.addKnowledgeItem(obj)
                } catch (error) {
                    console.log(error)
                }
            },
            handleSubmit() {
                // Exit when the form isn't valid
                if (!this.checkFormValidity()) {
                    return
                }
                // Push the name to submitted names
                console.log(this.title)
                this.createKnowledgeItem()
                // Hide the modal manually
                this.$nextTick(() => {
                    this.$bvModal.hide('create-modal')
                })
            }
        },
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
