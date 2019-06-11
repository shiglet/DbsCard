<template>
  <div class="home">
    <h1>Amount</h1>
    <CardList :action="'GetAmount/' + $route.params.amount"/>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import HelloWorld from "@/components/HelloWorld.vue"; // @ is an alias to /src
import CardList from "@/components/CardList.vue";

@Component({
  components: {
    CardList
  }
})
export default class Amount extends Vue {}
</script>
