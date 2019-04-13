<template>
  <v-menu offset-y left min-width="200" v-if="user.login">
    <template v-slot:activator="{ on }">
      <v-btn class="profile-btn" d-flex large depressed v-on="on">
        {{ user.login }}
        <v-avatar size="40" class="ml-3 mr-4" color="white">
          <img src="https://cdn3.iconfinder.com/data/icons/users-6/100/654853-user-men-2-512.png" alt="avatar" />
        </v-avatar>
        <v-icon>expand_more</v-icon>
      </v-btn>
    </template>
    <v-list>
      <v-list-tile @click="">
        <v-list-tile-title>Profile</v-list-tile-title>
        <v-list-tile-action style="justify-content: flex-end !important">
          <v-icon>person</v-icon>
        </v-list-tile-action>
      </v-list-tile>
      <v-divider style="width: 180px; margin: 0 auto"></v-divider>
      <v-list-tile @click="onLogOut">
        <v-list-tile-title>Logout</v-list-tile-title>
        <v-list-tile-action style="justify-content: flex-end !important">
          <v-icon>exit_to_app</v-icon>
        </v-list-tile-action>
      </v-list-tile>
    </v-list>
  </v-menu>
</template>

<script>
import { mapState, mapActions } from 'vuex'
export default {
  computed: {
    ...mapState(['user'])
  },
  methods: {
    ...mapActions(['logOut']),
    onLogOut() {
      this.logOut()
      this.$router.push('/authenticate')
    }
  }
}
</script>

<style>
.profile-btn {
  background-color: #f5f5f5;
  min-width: 170px;
  padding: 20px;
  justify-content: space-between;
}
</style>
