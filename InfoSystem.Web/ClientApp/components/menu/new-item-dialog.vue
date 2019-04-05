<template>
  <v-edit-dialog lazy persistent ref="newMenuItemDialog" style="width: 36px">
    <v-btn flat icon style="width: 36px">
      <v-icon dark>star</v-icon>
    </v-btn>
    <template v-slot:input>
      <v-text-field v-model="title" class="mt-4" label="Title"></v-text-field>
      <v-text-field v-model="icon" label="Icon"></v-text-field>
      <v-btn color="error" flat @click="clear">Cancel</v-btn>
      <v-btn color="primary" flat @click="create">Create</v-btn>
    </template>
  </v-edit-dialog>
</template>

<script>
import { mapActions } from 'vuex'
export default {
  data: () => ({
    title: '',
    icon: ''
  }),
  computed: {},
  methods: {
    ...mapActions(['addMenuItem']),
    create() {
      this.addMenuItem({
        link: this.$route.path,
        icon: this.icon,
        title: this.title
      })
      this.clear()
    },
    clear() {
      this.title = ''
      this.icon = ''
      this.$refs['newMenuItemDialog'].isActive = false
    }
  }
}
</script>

<style scoped>
.list_tile_last{
	border-top: 1px solid #52A8B6;
	border-bottom: 1px solid #52A8B6;
}
</style>
