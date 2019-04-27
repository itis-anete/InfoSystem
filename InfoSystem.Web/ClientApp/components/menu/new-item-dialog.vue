<template>
  <v-edit-dialog lazy persistent ref="newMenuItemDialog" style="width: 36px">
    <v-btn flat icon style="width: 36px">
      <v-icon dark>star</v-icon>
    </v-btn>
    <template v-slot:input>
      <v-text-field v-model="title" class="mt-4" label="Title" />
      <v-text-field v-model="icon" label="Icon" />
      <v-btn color="error" flat @click="clear">Cancel</v-btn>
      <v-btn color="primary" flat @click="create">Create</v-btn>
    </template>
  </v-edit-dialog>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator'

import { getModule } from 'vuex-module-decorators'
import menu from '@/store/menu'

@Component({
  name: 'MenuNewItemDialog'
})
export default class extends Vue {
  menuStore = getModule(menu, this.$store)

  title = ''
  icon = ''

  $refs!: {
    newMenuItemDialog: any
  }

  create() {
    this.menuStore.addMenuItem({
      link: this.$route.path,
      icon: this.icon,
      title: this.title
    })
    this.clear()
  }

  clear() {
    this.title = ''
    this.icon = ''
    this.$refs.newMenuItemDialog.isActive = false
  }
}
</script>


<style scoped>
.list_tile_last {
  border-top: 1px solid #52a8b6;
  border-bottom: 1px solid #52a8b6;
}
</style>
