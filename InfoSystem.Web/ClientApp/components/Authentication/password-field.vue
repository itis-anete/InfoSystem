<template>
  <v-text-field
    outline
    v-model="localPassword"
    :append-icon="showPassword ? 'visibility_off' : 'visibility'"
    :type="showPassword ? 'text' : 'password'"
    label="Password"
    @keyup.enter="submit"
    @click:append="showPassword = !showPassword"
    :error-messages="passwordErrors"
    @input="v.password.$touch()"
    @blur="v.password.$touch()"
  />
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator'
import { validationMixin } from 'vuelidate'
import { required, minLength } from 'vuelidate/lib/validators'

@Component({
  name: 'AuthenticationPasswordField',
  mixins: [validationMixin]
})
export default class extends Vue {
  showPassword: Boolean = false

  @Prop(String) password!: string
  @Prop() submit!: Function
  @Prop() v

  passwordErrors() {
    const errors: string[] = []
    if (!this.v.password.$dirty) return errors
    !this.v.password.minLength && errors.push('Password must be at most 6 characters long')
    !this.v.password.required && errors.push('Password is required.')
    return errors
  }

  get localPassword() {
    return this.password
  }

  set localPassword(value) {
    this.$emit('update:password', value)
  }
}
</script>

<style>
</style>
