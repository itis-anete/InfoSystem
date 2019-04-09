<template>
  <div>
    <authentication-card
      v-model="isSignUp"
      :switchText="`Don't have an account?`"
      :switchLink="`Sign Up`"
      :buttonText="`Log In`"
      :onSubmit="logIn"
    ></authentication-card>
  </div>
</template>

<script>
import { mapActions } from 'vuex'
import AuthenticationCard from './authentication-card.vue'
export default {
  props: ['value'],
  components: {
    AuthenticationCard
  },
  computed: {
    isSignUp: {
      get() {
        return this.value
      },
      set(val) {
        this.$emit('input', val)
      }
    }
  },
  methods: {
    ...mapActions(['authenticate']),
    async logIn(username, password) {
      await this.authenticate({ login: username, password: password })
      this.$router.push('/')
    }
  }
}
</script>

<style scoped>
</style>