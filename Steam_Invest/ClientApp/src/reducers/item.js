const defaultState = {
    items: []
}

export default (state = defaultState, action) => {
    switch (action.type) {

        case "FETCH_ITEMS_SUCCESS":
            return { ...state, items: action.data }

        case 'POST_ITEM_START':
            return {...state, isLoadingPostItem: true}
        case 'POST_ITEM_SUCCESS':
            return { ...state, isLoadingPostItem: false }

        case 'PUT_ITEM_START':
            return {...state, isLoadingPostItem: true}
        case 'PUT_ITEM_SUCCESS':
            return { ...state, isLoadingPostItem: false }

        case 'DELETE_ITEM_START':
            return {...state, isLoadingPostItem: true}
        case 'DELETE_ITEM_SUCCESS':
            return { ...state, isLoadingPostItem: false }

        case 'SET_ITEM':
            return { ...state, item: action.data }
        default:
            return state
    }
};