<template>
  <div>
      <b-container fluid="lg">
          <h3 class="mb-2">Knowledge Items:</h3>
          <b-button v-b-modal.create-modal block variant="primary">Create a Knowledge Item</b-button>
          <b-modal id="create-modal"
                   size="lg"
                   @show="resetModal"
                   @hidden="resetModal"
                   @ok="handleCreateOk"
                   title="Create Knowledge Item Form">
              <b-form ref="createForm" @submit.stop.prevent="handleCreateSubmit">
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
                                    v-model="date"
                                    :state="dateState"
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
                                    v-model="author"
                                    :state="authorState"
                                    type="text"
                                    required
                                    placeholder="Enter name of creator">
                      </b-form-input>
                  </b-form-group>
              </b-form>
          </b-modal>
          <b-modal id="edit-modal"
                   size="lg"
                   @hidden="resetModal"
                   @ok="handleEditOk"
                   title="Edit Knowledge Item Form">
              <b-form ref="editForm" @submit.stop.prevent="handleEditSubmit">
                  <b-form-group id="input-group-title"
                                invalid-feedback="Title is required"
                                label="New Title:"
                                label-for="edited-title-input">
                      <b-form-input id="edited-title-input"
                                    v-model="title"
                                    :state="titleState"
                                    type="text"
                                    required
                                    placeholder="Enter edited title">
                      </b-form-input>
                  </b-form-group>
                  <b-form-group id="input-group-summary"
                                invalid-feedback="Summary is required"
                                label="New Summary:"
                                label-for="edited-summary-input">
                      <b-form-textarea id="edited-summary-input"
                                       v-model="summary"
                                       :state="summaryState"
                                       type="text"
                                       required
                                       placeholder="Enter edited summary"
                                       :rows="6">
                      </b-form-textarea>
                  </b-form-group>
                  <b-form-group id="input-group-editedDate"
                                invalid-feedback="Date created is required"
                                label="Date Edited:"
                                label-for="edited-date-input">
                      <b-form-input id="edited-date-input"
                                    v-model="date"
                                    :state="dateState"
                                    type="text"
                                    required
                                    placeholder="Enter date edited">
                      </b-form-input>
                  </b-form-group>
                  <b-form-group id="input-group-editedBy"
                                invalid-feedback="Editor name is required"
                                label="Edited By:"
                                label-for="edited-by-input">
                      <b-form-input id="edited-by-input"
                                    v-model="author"
                                    :state="authorState"
                                    type="text"
                                    required
                                    placeholder="Enter name of editor">
                      </b-form-input>
                  </b-form-group>
              </b-form>
          </b-modal>
          <div id="mess-list" v-if="this.knowledgeItemList">
              <div v-for="knowledgeItem in this.knowledgeItemList" :key="knowledgeItem.id" class="ItemBorder">
                  <h4>{{knowledgeItem.title}}</h4>
                  <p class="mb-3">{{knowledgeItem.summary}}</p>
                  <b-row class="pb-1">
                      <b-col>
                          <b-button variant="danger" id="deleteBtn" @click="deleteKnowledgeItem(knowledgeItem.id)">Delete</b-button>
                      </b-col>
                      <b-col>
                          <p class="KIfooterStamp">Created by {{knowledgeItem.createdBy}} on {{knowledgeItem.createdDate}}</p>
                      </b-col>
                  </b-row>
                  <b-row>
                      <b-col>
                          <b-button variant="secondary" id="editBtn" v-b-modal.edit-modal @click="preFillModal(knowledgeItem)">Edit</b-button>
                      </b-col>
                      <b-col>
                          <p class="KIfooterStamp">Last edited by {{knowledgeItem.editedBy}} on {{knowledgeItem.editedDate}}</p>
                      </b-col>
                  </b-row>
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
                date: '',
                author: '',
                editId: -1,
                titleState: null,
                summaryState: null,
                dateState: null,
                authorState: null
            }
        },
        methods: {
            resetModal() {
                this.title = '',
                this.summary = '',
                this.date = '',
                this.author = '',
                this.editId = -1,
                this.titleState = null,
                this.summaryState = null,
                this.dateState = null,
                this.authorState = null
            },
            preFillModal(knowledgeItem) {
                this.editId = knowledgeItem.id,
                this.title = knowledgeItem.title,
                this.summary = knowledgeItem.summary
            },
            checkFormValidity(isBeingEdited) {
                var valid

                if (isBeingEdited) {
                    valid = this.$refs.editForm.checkValidity()
                    if (this.editId == -1) {
                        valid = false
                    }
                } else {
                    valid = this.$refs.createForm.checkValidity()
                }
                
                this.titleState = this.title.length == 0 ? false : true
                this.summaryState = this.summary.length == 0 ? false : true
                this.dateState = this.date.length == 0 ? false : true
                this.authorState = this.author.length == 0 ? false : true

                console.log("Form validation: "+valid)
                return valid
            },
            handleCreateOk(bvModalEvt) {
                bvModalEvt.preventDefault()
                this.handleCreateSubmit()
            },
            handleEditOk(bvModalEvt) {
                bvModalEvt.preventDefault()
                this.handleEditSubmit()
            },
            handleCreateSubmit() {
                // Exit when the form isn't valid
                if (!this.checkFormValidity(false)) {
                    return
                }
                // Call create and push new item to store
                this.createKnowledgeItem()
                // Hide the modal manually
                this.$nextTick(() => {
                    this.$bvModal.hide('create-modal')
                })
            },
            handleEditSubmit() {
                // Exit when the form isn't valid
                if (!this.checkFormValidity(true)) {
                    return
                }
                // Call update and push changes to store
                this.editKnowledgeItem()
                // Hide the modal manually
                this.$nextTick(() => {
                    this.$bvModal.hide('edit-modal')
                })
            },
            async createKnowledgeItem() {
                var obj = {
                    title: this.title,
                    summary: this.summary,
                    createdDate: this.date,
                    editedDate: this.date,
                    createdBy: this.author,
                    editedBy: this.author
                }

                try {
                    await KnowledgeService.addKnowledgeItem(obj)
                } catch (error) {
                    console.log(error)
                }
            },
            async editKnowledgeItem() {
                var obj = {
                    id: this.editId,
                    title: this.title,
                    summary: this.summary,
                    editedDate: this.date,
                    editedBy: this.author
                }

                try {
                    await KnowledgeService.editKnowledgeItem(obj)
                } catch (error) {
                    console.log(error)
                }
            },
            async deleteKnowledgeItem(id) {
                try {
                    await KnowledgeService.deleteKnowledgeItem(id)
                }
                catch (error) {
                    console.log(error)
                }
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
