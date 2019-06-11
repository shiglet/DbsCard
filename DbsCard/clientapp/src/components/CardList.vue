<template>
  <div class="container">
    <div class="row" :key="i" v-for="i in Math.ceil(allCard.length / 3)">
      <div
        class="col-lg-4 col-md-4 col-xs-4"
        v-for="c in allCard.slice((i - 1) * 3, i * 3)"
        :key="c.id"
      >
        <img @error="onImageError" :src="c.cardImg">
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import axios, { AxiosResponse } from "axios";

interface Card {
  cardImg: string;
  cardName: string;
  id: Number;
  isLeader: boolean;
  isPr: boolean;
  baseCardNumber: string;
}
@Component
export default class CardList extends Vue {
  private cards: Card[] = [];
  @Prop() private action: string = "";

  get allCard() {
    return this.cards;
  }
  public onImageError(e: any) {
    console.log("Error");
    var splitArray = e.target.src.split("/");
    e.target.src =
      "http://www.dbs-cardgame.com/images/cardlist/cardimg/" +
      splitArray[splitArray.length - 1];
  }

  created() {
    this.$http
      .get(
        this.action.length <= 0
          ? "http://localhost:57462/api/Card"
          : "http://localhost:57462/api/Card/" + this.action
      )
      .then((response: AxiosResponse) => {
        var cardTemp: Card[] = response.data.map((val: any) => ({
          cardImg: val.CardImg,
          cardName: val.CardName,
          id: val.Id,
          isLeader: val.isLeader,
          isPr: val.isPr,
          baseCardNumber: val.BaseCardNumber
        }));
        for (let card of cardTemp) {
          var cardImgUrl =
            "https://static.cardgame.fr/images/cards_medium/" +
            card.baseCardNumber;

          if (card.isLeader == true) {
            cardImgUrl += "LF";
          }
          card.cardImg = cardImgUrl + ".png";
        }

        this.cards = cardTemp;
      });
  }
}
</script>