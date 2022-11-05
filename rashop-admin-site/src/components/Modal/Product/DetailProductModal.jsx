import { Modal, Button } from "react-bootstrap";
import DetailProductForm from "../../Form/Product/DetailProductForm";

function DetailProductModal({status, onClose, data}) {
  return (
    <Modal
        show={status}
        dialogClassName="modal-90w"
        size="lg"
        aria-labelledby="example-custom-modal-styling-title"
      >
        <Modal.Header>
          <Modal.Title id="example-custom-modal-styling-title">
            Chi tiết
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <DetailProductForm data={data}/>
        </Modal.Body>
        <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
      </Modal>
  );
}
export default DetailProductModal;
