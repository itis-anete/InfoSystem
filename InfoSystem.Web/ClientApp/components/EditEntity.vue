<template>
  <v-dialog
    v-model="localDialog"
    fullscreen
    hide-overlay
    transition="dialog-bottom-transition"
    scrollable
  >
    <v-card tile>
      <v-toolbar card dark color="primary">
        <v-toolbar-title class="ml-4">Edit Entity</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-toolbar-items class="mr-4">
          <v-btn dark flat @click="localDialog = false">Save</v-btn>
          <v-btn icon dark @click="localDialog = false">
            <v-icon>close</v-icon>
          </v-btn>
        </v-toolbar-items>
      </v-toolbar>
      <v-card-text>
        <v-layout row wrap justify-center>
          <v-flex xs4>
            <v-card>
              <v-data-table
                v-if="currentValues"
                :headers="headers"
                :items="currentValues"
                item-key="id"
              >
                <template v-slot:items="props">
                  <td>
                    <v-edit-dialog
                      :return-value.sync="props.item.content"
                      large
                      lazy
                      persistent
                      @save="save(props.item)"
                      @cancel="cancel"
                      @open="open"
                      @close="close"
                    >
                      <div>{{ props.item.content }}</div>
                      <template v-slot:input>
                        <v-text-field
                          v-model="props.item.content"
                          label="Edit"
                          single-line
                          counter
                          autofocus
                        ></v-text-field>
                      </template>
                    </v-edit-dialog>
                  </td>
                  <td class="text-xs-right">
                    <v-edit-dialog
                      :return-value.sync="props.item.attribute.name"
                      large
                      lazy
                      persistent
                      @save="save(props.item)"
                      @cancel="cancel"
                      @open="open"
                      @close="close"
                    >
                      <div>{{ props.item.attribute.name }}</div>
                      <template v-slot:input>
                        <div class="mt-3 title">Update Iron</div>
                      </template>
                      <template v-slot:input>
                        <v-select
                          :items="attributes"
                          item-text="name"
                          return-object
                          v-model="props.item.attribute"
                        ></v-select>
                      </template>
                    </v-edit-dialog>
                  </td>
                  <td class="text-xs-right">
                    <v-edit-dialog
                      :return-value.sync="props.item.attribute.valueType"
                      large
                      lazy
                      persistent
                      @save="save(props.item)"
                      @cancel="cancel"
                      @open="open"
                      @close="close"
                    >
                      <div>{{ props.item.attribute.valueType }}</div>
                      <template v-slot:input>
                        <v-select :items="types" v-model="props.item.attribute.valueType"></v-select>
                      </template>
                    </v-edit-dialog>
                  </td>
                </template>
              </v-data-table>
            </v-card>
          </v-flex>
        </v-layout>

        <v-snackbar v-model="snack" :timeout="3000" :color="snackColor">
          {{ snackText }}
          <v-btn flat @click="snack = false">Close</v-btn>
        </v-snackbar>
      </v-card-text>

      <div style="flex: 1 1 auto;"></div>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
export default {
  props: ['dialog'],
  data() {
    return {
      snack: false,
      snackColor: '',
      snackText: '',
      headers: [
        {
          text: 'Value',
          align: 'left',
          sortable: false
        },
        { text: 'Attribute', sortable: false },
        { text: 'Type', value: 'type' }
      ],
      types: ['number', 'string', 'boolean']
    }
  },
  methods: {
    ...mapActions({ editValue: 'values/editValue' }),
    save(item) {
      this.snack = true
      this.snackColor = 'success'
      this.snackText = 'Data saved'
      const value = {
        id: item.id,
        content: item.content,
        entityId: item.entityId,
        attributeId: item.attribute.id
      }
      this.editValue(value)
    },
    cancel() {
      this.snack = true
      this.snackColor = 'error'
      this.snackText = 'Canceled'
    },
    open() {
      this.snack = true
      this.snackColor = 'info'
      this.snackText = 'Dialog opened'
    },
    close() {
      this.snack = true
      this.snackColor = 'warning'
      this.snackText = 'Dialog closed'
    }
  },
  computed: {
    ...mapGetters({ currentValues: 'values/currentValues' }, { attributes: 'attributes' }),
    localDialog: {
      get() {
        return this.dialog
      },
      set(value) {
        this.$emit('update:dialog', value)
      }
    }
  }
}
</script>