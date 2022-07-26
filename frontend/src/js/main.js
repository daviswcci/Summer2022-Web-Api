import * as constants from "../components/constants";
import apiActions from "../api/api-actions";
import boardGame from "../components/boardGame";

// function that sets up our homepage
export default {
    setupMain
}

function setupMain(){
    console.log("Hello world!");
    // repopulate HTML
    apiActions.getRequest(constants.boardGameURL, boardGame.displayBoardGameIndex);
}