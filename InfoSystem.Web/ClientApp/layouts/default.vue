<template>
  <v-app style="background-color: #F4F6F9">
    <v-navigation-drawer mini-variant fixed app clipped v-model="drawer">
      <v-list two-line class="pt-0">
        <v-list-tile v-for="(item, i) in items" :key="i" :to="item.to" router exact>
          <v-list-tile-action>
            <v-tooltip right>
              <template v-slot:activator="{ on }">
                <v-icon v-on="on" v-html="item.icon" :class="{ active: isActive && i==1 }"></v-icon>
              </template>
              <span>{{item.title}}</span>
            </v-tooltip>
          </v-list-tile-action>
        </v-list-tile>
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
        <v-toolbar-side-icon @click="drawer = !drawer"></v-toolbar-side-icon>
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
export default {
  data() {
    return {
      title: 'InfoSystem',
      drawer: false,
      items: [
        {
          icon: 'home',
          title: 'Home',
          to: '/'
        },
        {
          icon: 'view_list',
          title: 'Registries',
          to: '/registries'
        }
      ]
    }
  },
  computed: {
    isActive() {
      return this.$nuxt.$route.path.includes('registries')
    }
  }
}
</script>

<style>
.v-toolbar__content{
	padding: 0px 0px !important;
}
.side-icon{
	height: 100%;
	width: 80px;
	border-right: 1px solid #eaeaea;
	display: flex;
	align-items: center;
	justify-content: center;
}
.active{
	color: #52a8b6 !important
}
</style>
