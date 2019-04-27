<template>
  <authentication-card
    :isSignUp.sync="isSignUp"
    :switchText="`Don't have an account?`"
    :switchLink="`Sign Up`"
    :buttonText="`Log In`"
    :onSubmit="logIn"
  />
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator'
import AuthenticationCard from './authentication-card.vue'
import { getModule } from 'vuex-module-decorators'
import users from '../../store/users'

@Component({
  name: 'Login',
  components: {
    AuthenticationCard
  }
})
export default class extends Vue {
  usersStore = getModule(users, this.$store)

  @Prop() value

  get isSignUp() {
    return this.value
  }
  set isSignUp(val) {
    this.$emit('input', val)
  }
  async logIn(username, password) {
    await this.usersStore.authenticate({ login: username, password: password })
    this.$router.push('/')
  }
}
</script>

<style scoped>
</style>