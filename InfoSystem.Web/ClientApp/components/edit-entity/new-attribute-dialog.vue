<template>
  <v-dialog v-model="newAttributeDialogActive" max-width="500px">
    <template v-slot:activator="{ on }">
      <v-btn flat v-on="on" color="primary">
        <v-icon class="mr-2">add</v-icon>Add Attribute
      </v-btn>
      <v-divider inset vertical></v-divider>
    </template>
    <v-card>
      <v-card-title>
        <span class="headline">Add new attribute</span>
      </v-card-title>
      <v-card-text>
        <v-container grid-list-md>
          <v-layout wrap>
            <v-flex xs6>
              <v-text-field
                v-model="attributeName"
                label="Attribute Name"
                single-line
                counter
                autofocus
              ></v-text-field>
            </v-flex>
            <v-flex xs6>
              <v-switch
                color="primary"
                v-model="valueType"
                :label="`${valueType ? 'Complex' : 'Simple'}`"
              ></v-switch>
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
      attributeName: '',
      valueType: false,
      newAttributeDialogActive: false
    }
  },
  computed: {
    ...mapGetters(['attributes', 'types'])
  },
  methods: {
    ...mapActions(['addAttribute']),
    create() {
      const attribute = {
        attributeName: this.attributeName,
        valueType: this.valueType ? 'Complex' : 'Simple',
        typeName: this.types.find(x => x.id == this.$route.params.id).name
      }
      this.addAttribute(attribute)
      this.clear()
    },
    clear() {
      this.attributeName = ''
      this.valueType = false
      this.newAttributeDialogActive = false
    }
  }
}
</script>
