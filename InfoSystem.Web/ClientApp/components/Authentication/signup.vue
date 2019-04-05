<template>
  <div>
    <authentication-card
      v-model="isSignUp"
      :switchText="`Have an account?`"
      :switchLink="`Log In`"
      :buttonText="`Sign Up`"
      :onSubmit="signUp"
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
    signUp(username, password) {
      console.log(username, password)
    }
  }
}
</script>
