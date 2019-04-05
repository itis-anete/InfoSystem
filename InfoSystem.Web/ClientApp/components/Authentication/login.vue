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
    logIn(username, password) {
      console.warn(username, password)
    }
  }
}
</script>

<style scoped>
</style>