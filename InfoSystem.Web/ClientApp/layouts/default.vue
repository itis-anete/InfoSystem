<template>
  <v-app style="background-color: #F4F6F9">
    <v-navigation-drawer mini-variant class="layout-drawer" fixed app clipped v-model="drawerActive">
      <v-list two-line class="pt-0">
        <menu-list-tile v-for="(item, i) in sortedMenuItems" :key="i" :item="item" :index="i" />
      </v-list>
    </v-navigation-drawer>
    <v-toolbar fixed app flat height="80" clipped-left class=" top-toolbar">
      <div class="side-icon">
        <v-toolbar-side-icon @click="drawerActive = !drawerActive" />
      </div>
      <img src="../assets/logo.png" alt="logo" style="height: 50px" class="ml-4" />
      <v-toolbar-title v-text="title" />
      <v-spacer />
      <v-toolbar-items>
        <new-menu-item-dialog class="mr-4" />
        <user-profile />
      </v-toolbar-items>
    </v-toolbar>
    <v-content>
      <nuxt />
    </v-content>
  </v-app>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator'
import { Getter, Action, State } from 'vuex-class'
import { MenuItem } from '../models/menuItem'

import NewMenuItemDialog from '../components/menu/new-item-dialog.vue'
import MenuListTile from '../components/menu/list-tile.vue'
import UserProfile from '../components/menu/user-profile.vue'

@Component({
  components: {
    NewMenuItemDialog,
    MenuListTile,
    UserProfile
  },
  middleware: ['loadMenuItems']
  // middleware: ['authentication', 'loadMenuItems']
})
export default class extends Vue {
  @Getter('menu/sortedMenuItems') sortedMenuItems!: MenuItem[]
  @Getter('menu/drawer') drawer!: Boolean

  private title = 'InfoSystem'

  public get drawerActive(): Boolean {
    return this.drawer
  }
  public set drawerActive(value: Boolean) {
    this.$store.dispatch('menu/setDrawer', value)
  }
}
</script>

<style>
.v-toolbar__content {
  padding: 0px 0px !important;
}
.top-toolbar {
  border-bottom: 1px solid #eaeaea;
  background-color: white !important;
}
.side-icon {
  height: 100%;
  width: 80px;
  border-right: 1px solid #eaeaea;
  display: flex;
  align-items: center;
  justify-content: center;
}
.layout-drawer {
  height: calc(100% - 80px) !important;
  overflow-y: auto;
}
.layout-drawer::-webkit-scrollbar {
  display: none;
}
</style>
