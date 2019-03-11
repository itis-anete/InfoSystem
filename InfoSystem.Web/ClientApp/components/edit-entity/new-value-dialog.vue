<template>
  <v-dialog v-model="newValueDialogActive" max-width="500px">
    <template v-slot:activator="{ on }">
      <v-btn flat v-on="on" color="primary">
        <v-icon class="mr-2">add</v-icon>Add Value
      </v-btn>
      <v-divider inset vertical></v-divider>
    </template>
    <v-card>
      <v-card-title>
        <span class="headline">Add new value</span>
      </v-card-title>
      <v-card-text>
        <v-container grid-list-md>
          <v-layout wrap>
            <v-flex xs6>
              <v-text-field v-model="content" label="Content" single-line counter autofocus></v-text-field>
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
        <v-btn color="error" flat @click="clear">Cancel</v-btn>
        <v-btn color="primary" flat @click="create">Create</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
export default {
  props: ['entityId'],
  data() {
    return {
      content: '',
      attribute: null,
      newValueDialogActive: false
    }
  },
  computed: {
    ...mapGetters(['attributes'])
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
      this.clear()
    },
    clear() {
      this.content = ''
      this.attribute = null
      this.newValueDialogActive = false
    }
  }
}
</script>
