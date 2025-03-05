package oseg.petstore_examples

import org.openapitools.client.infrastructure.*
import org.openapitools.client.apis.*
import org.openapitools.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class UploadFileExample
{
    fun uploadFile()
    {
        ApiClient.accessToken = "YOUR_ACCESS_TOKEN"

        try
        {
            val response = PetApi().uploadFile(
                petId = 12345,
                additionalMetadata = "Additional data to pass to server",
                file = File("/path/to/file"),
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PetApi#uploadFile")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PetApi#uploadFile")
            e.printStackTrace()
        }
    }
}
