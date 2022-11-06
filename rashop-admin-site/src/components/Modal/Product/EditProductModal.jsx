import { Modal, Button } from "react-bootstrap";
import EditProductForm from "../../Form/Product/EditProductForm";
function EditProductModal({status, onClose, data}) {
  return (
    <Modal
        show={status}
        dialogClassName="modal-90w"
        size="lg"
        aria-labelledby="example-custom-modal-styling-title"
      >
        <Modal.Header>
          <Modal.Title id="example-custom-modal-styling-title">
            Chỉnh sửa
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <EditProductForm data={data} onSubmit={()=> onClose()}/>
        </Modal.Body>
        <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
      </Modal>
  );
}
export default EditProductModal;
