<template>
  <v-toolbar card color="#eee">
    <v-toolbar-items>
      <v-btn color="primary" flat @click="create">
        <v-icon class="mr-2">add</v-icon>Create
      </v-btn>
      <v-divider inset vertical></v-divider>
    </v-toolbar-items>
  </v-toolbar>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
export default {
  computed: {
    ...mapGetters(['types'])
  },
  methods: {
    ...mapActions(['addEntity']),
    create() {
      this.addEntity(this.types.find(x => x.id == this.$route.params.id).name)
    }
  }
}
</script>