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
import { mapActions } from 'vuex'
export default {
  methods: {
    ...mapActions(['addEntity']),
    create() {
      this.addEntity(this.$route.params.typeName)
    }
  }
}
</script>