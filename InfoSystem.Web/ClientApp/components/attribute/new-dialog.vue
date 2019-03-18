<template>
  <v-dialog v-model="dialog" persistent max-width="500">
    <template v-slot:activator="{ on }">
      <v-btn color="primary" flat v-on="on">
        <v-icon class="mr-2">add</v-icon>Add
      </v-btn>
    </template>
    <v-card>
      <v-card-title class="headline">Add attribute</v-card-title>
      <v-card-text>
        <v-switch v-model="complex" color="primary" :label="`${complex ? 'Complex' : 'Simple'}`"></v-switch>
        <v-layout align-center justify-space-between>
          <v-flex xs5>
            <v-text-field label="Key" v-model="key"></v-text-field>
          </v-flex>:
          <v-flex xs6>
            <v-text-field label="Value" v-model="value"></v-text-field>
          </v-flex>
        </v-layout>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="green darken-1" flat @click="clear">Cancel</v-btn>
        <v-btn color="green darken-1" flat @click="add">Add</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
export default {
  data: () => ({
    dialog: false,
    key: '',
    value: '',
    complex: false
  }),
  computed: {
    ...mapGetters(['types'])
  },
  methods: {
    ...mapActions(['addAttribute']),
    add() {
      const attribute = {
        key: this.key,
        value: this.value,
        typeId: this.types.find(x => x.name == this.$route.params.typeName).id,
        entityId: this.$route.params.id
      }
      this.addAttribute(attribute)
      this.clear()
    },
    clear() {
      this.key = ''
      this.value = ''
      this.dialog = false
    }
  }
}
</script>
