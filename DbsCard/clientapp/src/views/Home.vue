<template>
  <div class="home">
    <CardList></CardList>
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
export default class Home extends Vue {}
</script>
