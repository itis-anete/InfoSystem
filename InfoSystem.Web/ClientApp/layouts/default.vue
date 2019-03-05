<template>
  <v-app style="background-color: #F4F6F9">
    <v-navigation-drawer mini-variant fixed app width="200">
      <v-list two-line>
        <v-list-tile v-for="(item, i) in items" :key="i" :to="item.to" router exact>
          <v-list-tile-action>
            <v-tooltip right>
              <template v-slot:activator="{ on }">
                <v-icon v-on="on" v-html="item.icon"></v-icon>
              </template>
              <span>{{item.title}}</span>
            </v-tooltip>
          </v-list-tile-action>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>
    <v-toolbar fixed app flat style="border-bottom: 1px solid #eaeaea; background-color: white">
      <v-toolbar-title v-text="title"/>
      <v-spacer/>
    </v-toolbar>
    <v-content>
      <v-container>
        <nuxt/>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      title: "InfoSystem",
      miniVariant: true,
      items: [
        {
          icon: "apps",
          title: "Welcome",
          to: "/"
        },
        {
          icon: "bubble_chart",
          title: "Registry",
          to: "/registry"
        }
      ]
    };
  }
};
</script>
