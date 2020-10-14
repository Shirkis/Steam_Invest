import React from 'react'
import { IconButton, MenuItem, Menu, Button, Grid, Switch } from '@material-ui/core'
import MoreVertIcon from '@material-ui/icons/MoreVert'
import classnames from 'classnames'
import Modal from './Modal'

const styles = theme => ({
  switchName: {
    fontSize: 16,
    fontWeight: 'bold',
    color: '#242421'
  },
  switchBase: {
    color: '#120772'
  },
  switchBar: {
    backgroundColor: '#120772'
  },
  switchRoot: {
    top: 4,
    position: 'relative'
  }
})

class PaperMenu extends React.Component {
  constructor(props){
    super(props);
  }

  state = {
    anchorEl: null,
    deleteModalOpened: false
  }

  static defaultProps = {
    deleteLabel: "Удалить",
    editLabel: "Редактировать",
    askOnDelete: undefined,
    modalTitle: "Удаление",
    modalConfirmLabel: "Удалить",
    className: "",
    style: {}
  }

  openDeleteModal = () => {
    this.setState({ deleteModalOpened: true })
  }

  closeDeleteModal = () => {
    this.setState({ deleteModalOpened: false })
  }

  openMenu(e) {
    e.preventDefault();
    e.stopPropagation();
    this.setState({
      anchorEl: e.currentTarget
    })
  }

  closeMenu(e) {
    e.stopPropagation()
    this.setState({
      anchorEl: null
    })
  }

  onEdit = (event) => {
    let { handleEdit } = this.props;
    if(handleEdit) handleEdit();
    this.closeMenu(event);
  }

  onDelete = (event) => {
    let { handleDelete, askOnDelete } = this.props;
    if(askOnDelete) this.openDeleteModal();
    else if(handleDelete) handleDelete();
    this.closeMenu(event);
  }

  onModalConfirm = () => {
    let { handleDelete } = this.props;
    if(handleDelete) handleDelete();
    this.closeDeleteModal();
  }


  render() {
    const { deleteLabel, editLabel, askOnDelete, modalTitle, modalConfirmLabel, className, style, subDelete, askOnSubDelete, classes, onChangeSub, checkedSub } = this.props;

    return (
      <>
      <Modal
        title={modalTitle}
        open={this.state.deleteModalOpened}
        classes={{ paper: { minWidth: 500 } }}
        requestClose={() => this.closeDeleteModal()}
        primary={
          <Button onClick={this.onModalConfirm} variant="raised" color="primary">
            {modalConfirmLabel}
          </Button>
        }
        secondary={<Button onClick={() => this.closeDeleteModal()}>Отмена</Button>}
      >
        <div style={{ fontSize: 18 }}>{askOnDelete}</div>
        {subDelete && (
        <Grid container alignItems="center">
          <Grid item>
            <Switch
              color="primary"
              classes={{
                switchBase: styles.switchBase,
                bar: styles.switchBar,
                root: styles.switchRoot
              }}
              checked={checkedSub}
              onChange={(e, checked) => onChangeSub(e, checked)}
            />
          </Grid>
          <Grid item>
            <span
              className={styles.switchName}
              style={{
                color:'#242421'
              }}
            >
              {askOnSubDelete}
            </span>
          </Grid>
        </Grid>
        )}
      </Modal>
      <div>
        <IconButton
          className={classnames(className, {
            MenuButtonRelate: this.props.relate
          }, 'MenuButton'
          )}
          style={style}
          aria-owns={this.state.anchorEl ? 'menu' : null}
          aria-haspopup="true"
          onClick={e => this.openMenu(e)}
        >
          <MoreVertIcon />
        </IconButton>
        <Menu
          id="menu"
          anchorEl={this.state.anchorEl}
          open={Boolean(this.state.anchorEl)}
          onClose={e => this.closeMenu(e)}
        >
          <MenuItem onClick={this.onEdit}>{editLabel}</MenuItem>
          <MenuItem onClick={this.onDelete}>{deleteLabel}</MenuItem>
        </Menu>
      </div>
      </>
    )
  }
}

export default PaperMenu