package oseg.namsor_examples

import app.namsor.client.infrastructure.*
import app.namsor.client.apis.*
import app.namsor.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class AnonymizeExample
{
    fun anonymize()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        try
        {
            AdminApi().anonymize(
                source = "source",
                anonymized = true,
            )
        } catch (e: ClientException) {
            println("4xx response calling AdminApi#anonymize")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AdminApi#anonymize")
            e.printStackTrace()
        }
    }
}
