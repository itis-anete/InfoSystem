<template>
  <authentication-card :isSignUp.sync="isSignUp" :switchText="`Have an account?`" :switchLink="`Log In`" :buttonText="`Sign Up`" :onSubmit="signUp" />
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator'
import AuthenticationCard from './authentication-card.vue'
import { getModule } from 'vuex-module-decorators'
import users from '../../store/users'

@Component({
  name: 'SignUp',
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

  async signUp(username, password) {
    await this.usersStore.register({ login: username, password: password })
    this.$router.push('/')
  }
}
</script>
