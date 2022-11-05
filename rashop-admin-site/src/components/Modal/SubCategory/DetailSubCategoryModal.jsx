import { Modal, Button } from "react-bootstrap";
import DetailSubCategoryForm from "../../Form/SubCategory/DetailSubCategoryForm";

function DetailSubCategoryModal({status, onClose, data}) {
  return (
    <Modal show={status}>
      <Modal.Header>
        <Modal.Title>Chi tiết</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <DetailSubCategoryForm data={data} />
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
    </Modal>
  );
}
export default DetailSubCategoryModal;
