package oseg.chatwoot_examples

import com.chatwoot.client.infrastructure.*
import com.chatwoot.client.apis.*
import com.chatwoot.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class DeleteAnAgentBotExample
{
    fun deleteAnAgentBot()
    {
        ApiClient.apiKey["api_access_token"] = "PLATFORM_APP_API_KEY"

        try
        {
            AgentBotsApi().deleteAnAgentBot(
                id = 0,
            )
        } catch (e: ClientException) {
            println("4xx response calling AgentBotsApi#deleteAnAgentBot")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AgentBotsApi#deleteAnAgentBot")
            e.printStackTrace()
        }
    }
}
