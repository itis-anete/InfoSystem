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
            <v-select
              v-if="complex"
              :items="types"
              return-object
              item-text="name"
              v-model="type"
              label="Key"
            ></v-select>
            <v-text-field v-else label="Key" v-model="key"></v-text-field>
          </v-flex>:
          <v-flex xs6>
            <v-select
              v-if="type && complex"
              :items="entities"
              return-object
              item-text="id"
              v-model="entity"
              label="Value"
            ></v-select>
            <v-text-field v-else-if="!complex" label="Value" v-model="value"></v-text-field>
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
    complex: false,
    type: null,
    entity: null
  }),
  computed: {
    ...mapGetters(['types', 'entities'])
  },
  watch: {
    type(value) {
      if (value) this.$store.dispatch('getEntities', value.name)
    }
  },
  methods: {
    ...mapActions(['addAttribute']),
    add() {
      const attribute = {
        key: this.complex ? `Complex:${this.type.name}` : this.key,
        value: this.complex ? this.entity.id : this.value,
        typeId: this.types.find(x => x.name == this.$route.params.typeName).id,
        entityId: this.$route.params.id
      }
      this.addAttribute(attribute)
      this.clear()
    },
    clear() {
      this.key = ''
      this.value = ''
      this.type = null
      this.entity = null
      this.complex = false
      this.dialog = false
    }
  }
}
</script>
