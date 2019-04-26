<template>
  <v-navigation-drawer class="drawer" fixed :class="{ left: drawerActive }" width="250">
    <v-subheader style="height: 47px">
      Entity Types
      <v-spacer />
      <new-type-dialog />
    </v-subheader>
    <v-divider />
    <v-list two-line subheader class="drawer-list">
      <type-list-tile v-for="(type, index) in types" :type="type" :key="type.name" />
    </v-list>
  </v-navigation-drawer>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator'

import { getModule } from 'vuex-module-decorators'
import menu from '@/store/menu'

import NewTypeDialog from './new/type-dialog.vue'
import TypeListTile from './type-list-tile.vue'

import { Type } from '@/models/type'

@Component({
  name: 'NavigationDrawer',
  components: {
    NewTypeDialog,
    TypeListTile
  }
})
export default class extends Vue {
  menuStore = getModule(menu, this.$store)

  get drawerActive() {
    return this.menuStore.Drawer
  }

  @Prop() readonly types!: Type[]
}
</script>

<style>
.v-small-dialog {
  width: inherit;
}
.left {
  transform: translateX(80px) !important;
  transition: transform 1s linear;
}
.drawer {
  margin-top: 81px !important;
  height: 100% !important;
  overflow-y: hidden;
}
.drawer-list {
  height: calc(100% - 120px) !important;
  overflow-y: auto;
}
.drawer-list::-webkit-scrollbar {
  display: none;
}
</style>
