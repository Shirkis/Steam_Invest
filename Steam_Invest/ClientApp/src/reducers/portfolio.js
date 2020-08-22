import { ACTION_TYPES } from "../actions/portfolio";
const initialState ={
    list:[]
}

export const portfolio = (state=initialState, action) =>{
    switch (action.type) {
        case ACTION_TYPES.FETCH_ALL:
            return {
                ...state,
                list:[...action.payload]
            }
            default:
                return state;
    }
}