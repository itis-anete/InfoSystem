<template>
  <v-dialog v-model="localNewValueDialogActive" max-width="500px">
    <v-card>
      <v-card-title>
        <span class="headline">New</span>
      </v-card-title>

      <v-card-text>
        <v-container grid-list-md>
          <v-layout wrap>
            <v-flex xs6>
              <v-text-field v-model="content" label="Value" single-line counter autofocus></v-text-field>
            </v-flex>
            <v-flex xs6>
              <v-select
                :items="attributes"
                item-text="name"
                label="Attribute"
                return-object
                v-model="attribute"
              ></v-select>
            </v-flex>
          </v-layout>
        </v-container>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="error" flat @click="localNewValueDialogActive = false">Cancel</v-btn>
        <v-btn color="primary" flat @click="create">Create</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
export default {
  props: ['newValueDialogActive', 'entityId'],
  data() {
    return {
      content: '',
      attribute: null,
      types: ['number', 'string', 'boolean']
    }
  },
  computed: {
    ...mapGetters(['attributes']),
    localNewValueDialogActive: {
      get() {
        return this.newValueDialogActive
      },
      set(value) {
        this.$emit('update:newValueDialogActive', value)
      }
    }
  },
  methods: {
    ...mapActions(['addValue']),
    create() {
      const value = {
        attributeId: this.attribute.id,
        entityId: this.entityId,
        content: this.content
      }
      this.addValue(value)
      this.localNewValueDialogActive = false
    }
  }
}
</script>

<style scoped>

</style>