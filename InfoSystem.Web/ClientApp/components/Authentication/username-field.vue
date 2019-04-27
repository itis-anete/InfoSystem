<template>
  <v-text-field
    append-icon="person"
    outline
    v-model="localUsername"
    label="Username"
    @keyup.enter="submit"
    :error-messages="nameErrors"
    @input="v.username.$touch()"
    @blur="v.username.$touch()"
  />
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator'
import { validationMixin } from 'vuelidate'
import { required } from 'vuelidate/lib/validators'

@Component({
  name: 'AuthenticationUsernameField',
  mixins: [validationMixin]
})
export default class extends Vue {
  @Prop(String) username!: string
  @Prop() submit!: Function
  @Prop() v

  nameErrors() {
    const errors: string[] = []
    if (!this.v.username.$dirty) return errors
    !this.v.username.required && errors.push('Username is required.')
    return errors
  }

  get localUsername() {
    return this.username
  }
  set localUsername(value) {
    this.$emit('update:username', value)
  }
}
</script>

<style>
</style>
