import { Modal, Button } from "react-bootstrap";
import AddProductForm from "../../Form/Product/AddProductForm";

function AddProductModal({status, onClose}) {
  return (
    <Modal
        show={status}
        dialogClassName="modal-90w"
        size="lg"
        aria-labelledby="example-custom-modal-styling-title"
      >
        <Modal.Header>
          <Modal.Title id="example-custom-modal-styling-title">
            Thêm mới
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <AddProductForm onSubmit={() => onClose()}/>
        </Modal.Body>
        <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
      </Modal>
  );
}
export default AddProductModal;
