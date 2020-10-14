import React from 'react'
import { withStyles, Grid, Button } from '@material-ui/core'
import { connect } from 'react-redux'
import ItemSection from './ItemSection'
import AddItemModal from './AddItemModal'
import { setItem, getItemsForPortfolio } from '../../actions/item'

let styles = theme => ({})

class Item extends React.Component {
  state = {
    dialogOpened: false
  }

  renderView() {
    const { closeDialog, openDialog, items } = this.props;
    let { dialogOpened } = this.state

    return (
      <Grid container> {/*spacing={16}*/}
        <Grid item>
            <AddItemModal dialogOpened={dialogOpened} closeDialog={() => this.closeDialog()} />
        </Grid>
        {console.log(this.props, this.state)}
        {
          items.map((item, i) => (
              <ItemSection key={i} item={item} openDialog={() => this.openDialog()} />
            ))
        }
      </Grid>
    )
  }

  openDialog() {
    this.setState({ dialogOpened: true });
  }

  closeDialog() {
    this.setState({ dialogOpened: false });
    this.props.setItem();
  }

  render() {
    return (
      <Grid container> {/*spacing={16}*/}
        <Button
            onClick={() => this.openDialog()}
            //variant="raised"
            color="primary"
          >
            Добавить
          </Button>
        <Grid item> {/*xs={12}*/}
          {this.renderView(this.state.view)}
        </Grid>
      </Grid>
    )
  }
}

export default connect(
  state => ({
    items: state.item.items
  }),
  dispatch => ({
    getItemsForPortfolio: () => {
      dispatch(getItemsForPortfolio())
    },
    setItem: (item) => {
      dispatch(setItem(item))
    }
  })
)(withStyles(styles)(Item))