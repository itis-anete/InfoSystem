<template>
  <v-app style="background-color: #F4F6F9">
    <v-navigation-drawer mini-variant class="layout-drawer" fixed app clipped v-model="drawerActive">
      <v-list two-line class="pt-0">
        <menu-list-tile v-for="(item, i) in sortedMenuItems" :key="i" :item="item" :index="i"></menu-list-tile>
      </v-list>
    </v-navigation-drawer>
    <v-toolbar fixed app flat height="80" clipped-left class="pr-4 top-toolbar">
      <div class="side-icon">
        <v-toolbar-side-icon @click="drawerActive = !drawerActive"></v-toolbar-side-icon>
      </div>
      <img src="../assets/logo.png" alt="logo" style="height: 50px" class="ml-4" />
      <v-toolbar-title v-text="title" />
      <v-spacer />
      <new-menu-item-dialog />
    </v-toolbar>
    <v-content>
      <nuxt />
    </v-content>
  </v-app>
</template>

<script>
import { mapGetters, mapState } from 'vuex'
import NewMenuItemDialog from '../components/menu/new-item-dialog.vue'
import MenuListTile from '../components/menu/list-tile.vue'
export default {
  components: {
    NewMenuItemDialog,
    MenuListTile
  },
  middleware: ['loadMenuItems'],
  data() {
    return {
      title: 'InfoSystem'
    }
  },
  computed: {
    ...mapState(['menu']),
    ...mapGetters(['sortedMenuItems']),
    drawerActive: {
      get() {
        return this.menu.drawer
      },
      set(value) {
        this.$store.dispatch('setDrawer', value)
      }
    }
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
