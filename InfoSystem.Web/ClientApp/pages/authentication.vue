<template>
  <v-container grid-list-xs fill-height>
    <v-layout row wrap justify-center align-center>
      <v-flex xs3>
        <transition name="component-fade" mode="out-in">
          <component :is="view" v-model="isSignUp"></component>
        </transition>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import SignUp from '../components/Authentication/signup.vue'
import LogIn from '../components/Authentication/login.vue'

export default {
  layout: 'authentication',
  components: {
    SignUp,
    LogIn
  },
  data: () => ({
    isSignUp: true
  }),
  computed: {
    view() {
      return this.isSignUp ? 'sign-up' : 'log-in'
    }
  }
}
</script>

<style scoped>
.component-fade-enter-active,
.component-fade-leave-active {
  transition: all 0.5s ease;
}
.component-fade-enter,
.component-fade-leave-to {
  opacity: 0;
  transform: translateX(30px);
}
</style>
