<template>
  <v-toolbar card color="#eee">
    <v-toolbar-items>
      <v-btn color="primary" flat @click="create">
        <v-icon class="mr-2">add</v-icon>Create
      </v-btn>
      <v-divider inset vertical></v-divider>
    </v-toolbar-items>
    <v-spacer></v-spacer>
    <v-progress-circular v-if="loading" class="px-5" indeterminate color="primary"></v-progress-circular>
  </v-toolbar>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
export default {
  methods: {
    ...mapActions(['addEntity']),
    create() {
      this.addEntity(this.$route.params.typeName)
    }
  },
  computed: {
    ...mapGetters(['loading'])
  }
}
</script>