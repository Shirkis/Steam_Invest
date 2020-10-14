import React from 'react'
import PaperMenu from '../common/PaperMenu'
import Collapse from '@material-ui/core/Collapse';
import { connect } from 'react-redux'
import {
  Grid,
  Paper,
  Button,
  Typography,
  withStyles
} from '@material-ui/core'
import { deleteItem, setItem } from '../../actions/item'

const styles = theme => ({
  title: {
    fontSize: 16,
    fontWeight: 'bold'
  },
  text: {
    fontSize: 16
  },
});

class ItemSection extends React.Component {
  state = {
    sectionOpen: false
  }

  toggle = () => {
    let sectionOpen = !this.state.sectionOpen;
    this.setState({ sectionOpen });
  }

  openDialog() {
    this.setState({ dialogOpened: true })
  }

  handleEdit = (item) => {
    this.props.setItem(item);
    this.props.openDialog();
  }

  render(){
    const { classes } = this.props;
    const {
      itemId,
      itemName,
    } = this.props.item;

    return (
      <Grid item xs={12}>
        <Paper className="PaperEditable">
        <PaperMenu handleDelete={() => this.props.deleteItem(itemId)} handleEdit={() => this.handleEdit(this.props.item)} />
          <Grid container spacing={16}>
            <Grid item xs={12}>
              <div className="PaperTitle">{itemName}</div>
            </Grid>
          </Grid>
        </Paper>
      </Grid>
    )}
}

//export default withStyles(styles)(TteTypesSection)

export default connect(
  state => ({}),
  dispatch => ({
    deleteItem: (itemId) => {
      dispatch(deleteItem(itemId))
    },
    setItem: (item) => {
      dispatch(setItem(item))
    }
  })
)(withStyles(styles)(ItemSection))