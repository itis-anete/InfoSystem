<template>
  <v-toolbar card color="#eee">
    <v-toolbar-items>
      <v-btn color="primary" flat @click="add">
        <v-icon class="mr-2">add</v-icon>Add
      </v-btn>
      <v-divider inset vertical></v-divider>
    </v-toolbar-items>
  </v-toolbar>
</template>

<script>
import { mapActions } from 'vuex'
export default {
  methods: {
    add() {}
  }
}
</script>