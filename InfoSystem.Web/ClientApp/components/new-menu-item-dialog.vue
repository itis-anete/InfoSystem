<template>
  <v-edit-dialog lazy persistent ref="newMenuItemDialog">
    <v-list-tile key="last" class="list_tile_last">
      <v-list-tile-action>
        <v-tooltip right>
          <template v-slot:activator="{ on }">
            <v-icon v-on="on">add</v-icon>
          </template>
          <span>Create</span>
        </v-tooltip>
      </v-list-tile-action>
    </v-list-tile>
    <template v-slot:input>
      <v-text-field v-model="title" class="mt-4" label="Title"></v-text-field>
      <v-text-field v-model="link" label="Link"></v-text-field>
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
    icon: '',
    link: ''
  }),
  computed: {},
  methods: {
    ...mapActions(['addMenuItem']),
    create() {
      this.addMenuItem({
        link: this.link,
        icon: this.icon,
        title: this.title
      })
      this.clear()
    },
    clear() {
      this.title = ''
      this.icon = ''
      this.link = ''
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
