<template>
  <v-container class="ma-0" style="margin-left: 250px !important">
    <v-layout justify-center>
      <v-flex xs12>
        <v-card v-if="entities">
          <v-toolbar card color="#eee">
            <v-toolbar-items>
              <new-entity-dialog></new-entity-dialog>
              <v-divider inset vertical></v-divider>
            </v-toolbar-items>
          </v-toolbar>
          <registry-grid :headers="headers" :entities="entities"></registry-grid>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
import RegistryGrid from '~/components/registry/grid.vue'
import NewEntityDialog from '~/components/registry/new-entity-dialog.vue'
export default {
  name: 'Registry',
  validate({ params }) {
    return !isNaN(+params.id)
  },
  components: {
    RegistryGrid,
    NewEntityDialog
  },
  data: () => ({
    headers: [{ text: 'Id', sortable: false }, { text: '', sortable: false }]
  }),
  computed: {
    ...mapGetters(['entities', 'types'])
  },
  methods: {
    ...mapActions(['addEntity']),
    add() {
      const entity = {
        typeName: this.types.find(x => x.id == this.$route.params.id).name,
        identificator: this.identificator
      }
      this.addEntity(entity)
    }
  },
  async fetch({ store, params }) {
    await store.dispatch('getEntities', params.id)
  }
}
</script>
