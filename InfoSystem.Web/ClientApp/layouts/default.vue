<template>
  <v-app style="background-color: #F4F6F9">
    <v-navigation-drawer mini-variant fixed app clipped v-model="drawerActive">
      <v-list two-line class="pt-0">
        <v-list-tile
          v-for="(item, i) in sortedMenuItems"
          :key="i"
          :to="getProperty(item, 'link')"
          router
          exact
        >
          <v-list-tile-action>
            <v-tooltip right>
              <template v-slot:activator="{ on }">
                <v-icon
                  v-on="on"
                  v-html="getProperty(item, 'icon')"
                  :class="{ active: isActive && i==1 }"
                ></v-icon>
              </template>
              <span>{{getProperty(item, 'title')}}</span>
            </v-tooltip>
          </v-list-tile-action>
        </v-list-tile>
        <new-menu-item-dialog></new-menu-item-dialog>
      </v-list>
    </v-navigation-drawer>
    <v-toolbar
      fixed
      app
      flat
      style="border-bottom: 1px solid #eaeaea; background-color: white;"
      height="80"
      clipped-left
    >
      <div class="side-icon">
        <v-toolbar-side-icon @click="drawerActive = !drawerActive"></v-toolbar-side-icon>
      </div>
      <img src="../assets/logo.png" alt="logo" style="height: 50px" class="ml-4">
      <v-toolbar-title v-text="title"/>
      <v-spacer/>
    </v-toolbar>
    <v-content>
      <nuxt/>
    </v-content>
  </v-app>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
import NewMenuItemDialog from '../components/new-menu-item-dialog.vue'
import axios from 'axios'
export default {
  components: {
    NewMenuItemDialog
  },
  data() {
    return {
      title: 'InfoSystem'
    }
  },
  computed: {
    ...mapGetters(['drawer', 'menuItems']),
    drawerActive: {
      get() {
        return this.drawer
      },
      set(value) {
        this.$store.dispatch('setDrawer', value)
      }
    },
    sortedMenuItems() {
      return this.menuItems.sort((a, b) => {
        var titleA = a.find(x => x.key == 'title').value
        var titleB = b.find(x => x.key == 'title').value
        console.log(titleA)
        console.warn(titleB)
        console.error('qwe')
        if (titleA == 'Home' && titleB == 'Registries') return -1
        else if (titleA == 'Home') return -1
        else if (titleA == 'Registries') return -1
        else return 1
      })
    },
    isActive() {
      return this.$nuxt.$route.path.includes('registries')
    }
  },
  methods: {
    ...mapActions(['getMenuItems']),
    getProperty(item, key) {
      return item.find(x => x.key == key).value
    }
  },
  async created() {
    this.getMenuItems()
  }
}
</script>

<style>
.v-toolbar__content {
  padding: 0px 0px !important;
}
.side-icon {
  height: 100%;
  width: 80px;
  border-right: 1px solid #eaeaea;
  display: flex;
  align-items: center;
  justify-content: center;
}
.active {
  color: #52a8b6 !important;
}
</style>
